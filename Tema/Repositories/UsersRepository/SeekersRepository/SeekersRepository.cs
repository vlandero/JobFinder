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
    }
}
