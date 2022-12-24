using Tema.Models.Companies;
using Tema.Repositories.GenericRepository;

namespace Tema.Repositories.CompaniesRepository
{
    public interface ICompanyRepository : IGenericRepository<Company>
    {
        Task<Company> GetByName(string name);
    }
}
