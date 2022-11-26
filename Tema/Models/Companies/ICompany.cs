using System.ComponentModel.DataAnnotations;
using Tema.Models.Base;
using Tema.Models.Users;

namespace Tema.Models.Companies
{
    public interface ICompany : IBaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Location { get; set; }
        public List<Seeker> Employees { get; set; }
    }
}
