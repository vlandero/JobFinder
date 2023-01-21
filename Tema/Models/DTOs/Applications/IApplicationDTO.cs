namespace Tema.Models.DTOs.Applications
{
    public interface IApplicationDTO
    {
        long PostId { get; set; }
        string CompanyName { get; set; }
        string JobTitle { get; set; }
        string? CompanyLogo { get; set; }
    }
}
