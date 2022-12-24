using Tema.Models.Companies;

namespace Tema.Services.Companies
{
    public interface ICompanyService
    {
        Task Create(Company c);
        Task<Company> GetByName(string name);
        void DeleteAll();
        void Update(Company c);
    }
}
