
namespace Tema.Models.DTOs.Companies
{
    public interface ICompanyRequestDTO
    {
        string Name { get; set; }
        string Description { get; set; }
        string? Location { get; set; }
        string? Logo { get; set; }
    }
}
