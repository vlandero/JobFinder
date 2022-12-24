namespace Tema.Models.DTOs.Companies
{
    public class CompanyDTO : ICompanyDTO
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Location { get; set; }
    }
}
