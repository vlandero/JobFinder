using Microsoft.EntityFrameworkCore;
using Tema.Models;
using Tema.Models.Companies;
using Tema.Repositories.GenericRepository;

namespace Tema.Repositories.CompaniesRepository
{
    public class CompanyRepository : GenericRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(MyAppContext context) : base(context)
        {

        }
        public async Task<Company> GetByName(string name)
        {
            return await _table.FirstOrDefaultAsync<Company>(c => c.Name == name);
        }
    }
}
