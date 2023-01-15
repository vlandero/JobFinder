using Tema.Models.DTOs.Applications;
using Tema.Models.DTOs.Users;
using Tema.Models.Users.Finder;

namespace Tema.Models.DTOs.Finders
{
    public interface IFinderDTO : IUsersDTO<Finder>
    {
        string Resume { get; set; }
        string About { get; set; }
        List<ApplicationDTO> Applications { get; set; }
    }
}
