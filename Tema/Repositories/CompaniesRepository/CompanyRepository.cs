using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Tema.Models;
using Tema.Models.Companies;
using Tema.Models.DTOs.Finders;
using Tema.Models.DTOs.Response.Jobs;
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
            return await _table.FirstOrDefaultAsync(c => c.Name == name);
        }

        public Company GetByNameSync(string name)
        {
            return _table.FirstOrDefault(c => c.Name == name);
        }
        public Company GetCompanyFromSeeker(string email)
        {
            var cmp = from company in _context.Companies
                         join s in _context.Seekers on company.Id equals s.Company.Id
                         where s.Email == email
                         select company;
            System.Diagnostics.Debug.WriteLine("GetCompanyFromSeeker Repo" + JsonConvert.SerializeObject(cmp));
            return cmp.ToList()[0];
        }
    }
}
