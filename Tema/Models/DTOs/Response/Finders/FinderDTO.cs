using System.Text.Json.Serialization;
using Tema.Models.DTOs.Applications;
using Tema.Models.DTOs.Users;
using Tema.Models.Users.Finder;

namespace Tema.Models.DTOs.Finders
{
    public class FinderDTO : UsersDTO<Finder>, IFinderDTO
    {
        public string? Resume { get; set; }
        public string? About { get; set; }
        public List<ApplicationDTO> Applications { get; set; }
        public List<string> Skills { get; set; }

        [JsonConstructor]
        public FinderDTO() : base() { }

        public FinderDTO(Finder f, List<ApplicationDTO> applications) : base(f)
        {
            Resume = f.Resume;
            About = f.About;
            Applications = applications;
            Skills = f.Skills;
        }
    }
}
