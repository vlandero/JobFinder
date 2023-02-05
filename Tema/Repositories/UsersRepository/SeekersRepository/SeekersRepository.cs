using Microsoft.EntityFrameworkCore;
using Tema.Models;
using Tema.Models.Users.Seeker;
using Tema.Repositories.UsersRepository.GenericUsersRepository;

namespace Tema.Repositories.UsersRepository
{
    public class SeekersRepository : GenericUsersRepository<Seeker>, ISeekersRepository
    {
        public SeekersRepository(MyAppContext context) : base(context)
        {

        }

        public async Task<Seeker> GetByEmailWithCompanyId(string email)
        {
            var x = _table.Include(s => s.Company).FirstOrDefaultAsync(s => s.Email == email);
            return await x;
            
        }

        public async Task<Seeker> GetByIdWithCompanyId(Guid id)
        {
            var x = _table.Include(s => s.Company).FirstOrDefaultAsync(s => s.Id == id);
            return await x;
        }

        public async Task<Seeker> GetByUrlWithCompanyId(string url)
        {
            var x = _table.Include(s => s.Company).FirstOrDefaultAsync(s => s.Url == url);
            return await x;
        }

    }
}
