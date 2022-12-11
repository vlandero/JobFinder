using Tema.Models.Users.Finder;
using Tema.Repositories.UsersRepository.FindersRepository;
using Tema.Repositories.UsersRepository.GenericUsersRepository;
using Tema.Services.Users;

namespace Tema.Services.Finders
{
    public class FinderService : UserService<Finder>, IFinderService
    {

        public FinderService(IFindersRepository userRepository) : base(userRepository)
        {
        }
        
    }
}
