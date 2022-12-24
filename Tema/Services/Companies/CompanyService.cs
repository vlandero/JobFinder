using Tema.Models.Companies;
using Tema.Repositories.CompaniesRepository;

namespace Tema.Services.Companies
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task Create(Company c)
        {
            await _companyRepository.CreateAsync(c);
            await _companyRepository.SaveAsync();
        }

        public async Task<Company> GetByName(string name)
        {
            return await _companyRepository.GetByName(name);
        }
        public void DeleteAll()
        {
            _companyRepository.DeleteAll();
            _companyRepository.Save();
        }
        public void Update(Company c)
        {
            _companyRepository.Update(c);
            _companyRepository.Save();
        }

    }
}
