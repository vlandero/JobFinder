namespace Tema.Models.DTOs.Applicants
{
    public interface IApplicantDTO
    {
        string FinderEmail { get; set; }
        Guid JobId { get; set; }
    }
}
