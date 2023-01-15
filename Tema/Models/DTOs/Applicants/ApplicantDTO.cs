using System.Text.Json.Serialization;

namespace Tema.Models.DTOs.Applicants
{
    public class ApplicantDTO : IApplicantDTO
    {
        public string FinderEmail { get; set; }
        public Guid JobId { get; set; }

        [JsonConstructor]
        public ApplicantDTO() { }
    }
}
