using Tema.Models.Users;
using Tema.Repositories.UsersRepository;
using Tema.Services.Users;

namespace Tema.Services.Seekers
{
    public class SeekerService : UserService<Seeker>, ISeekerService
    {
        public SeekerService(ISeekersRepository userRepository) : base(userRepository)
        {
        }
    }
}
