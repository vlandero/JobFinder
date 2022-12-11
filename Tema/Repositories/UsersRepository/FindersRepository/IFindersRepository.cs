using Tema.Models.Users.Finder;
using Tema.Repositories.UsersRepository.GenericUsersRepository;

namespace Tema.Repositories.UsersRepository.FindersRepository
{
    public interface IFindersRepository : IGenericUsersRepository<Finder>
    {
    }
}
