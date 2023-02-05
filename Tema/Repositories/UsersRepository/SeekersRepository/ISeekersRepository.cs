using Tema.Models.Users.Seeker;
using Tema.Repositories.UsersRepository.GenericUsersRepository;

namespace Tema.Repositories.UsersRepository
{
    public interface ISeekersRepository : IGenericUsersRepository<Seeker>
    {
        Task<Seeker> GetByEmailWithCompanyId(string email);
        Task<Seeker> GetByIdWithCompanyId(Guid id);
        Task<Seeker> GetByUrlWithCompanyId(string url);
    }
}
